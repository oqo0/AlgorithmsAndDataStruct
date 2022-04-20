using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace Task3_1
{
    public class BechmarkClass
    {
        [Benchmark]
        public float GetDistClass()
        {
            var pointOne = new PointClass<float>(-1, 3);
            var pointTwo = new PointClass<float>(-1, 3);
            
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        
        [Benchmark]
        public float GetDistStructFloat()
        {
            var pointOne = new PointStruct<float>(-1, 3);
            var pointTwo = new PointStruct<float>(-1, 3);
            
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        
        [Benchmark]
        public double GetDistStructDouble()
        {
            var pointOne = new PointStruct<float>(-1, 3);
            var pointTwo = new PointStruct<float>(-1, 3);
            
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        
        [Benchmark]
        public float GetDistStructFloatNoSquare()
        {
            var pointOne = new PointStruct<float>(-1, 3);
            var pointTwo = new PointStruct<float>(-1, 3);
            
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;

            if ((x * x) + (y * y) == 0) return 0;
            
            FloatIntUnion union;
            union.i = 0;
            union.f = (x * x) + (y * y);
            union.i -= 1 << 23;
            union.i >>= 1;
            union.i += 1 << 29;
            
            return union.f;
        }

    }
    class Task3_1
    {
        
        public static float GetDistClass(PointClass<float> pointOne, PointClass<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        
        public static float GetDistStructFloat(PointStruct<float> pointOne, PointStruct<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        
        public static double GetDistStructDouble(PointStruct<double> pointOne, PointStruct<double> pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        
        public static float GetDistStructFloatNoSquare(PointStruct<float> pointOne, PointStruct<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;

            if ((x * x) + (y * y) == 0) return 0;
            
            FloatIntUnion union;
            union.i = 0;
            union.f = (x * x) + (y * y);
            union.i -= 1 << 23;
            union.i >>= 1;
            union.i += 1 << 29;
            
            return union.f;
        }
        
        public static void Main(string[] args)
        {
            Test.Case<float>(
                7.071068f,
                GetDistClass(
                    new PointClass<float>(-1, 3),
                    new PointClass<float>(6, 2)
                    )
                );
            Test.Case<float>(
                7.071068f,
                GetDistStructFloat(
                    new PointStruct<float>(-1, 3),
                    new PointStruct<float>(6, 2)
                )
            );
            Test.Case<double>(
                7.0710678118654755d,
                GetDistStructDouble(
                    new PointStruct<double>(-1, 3),
                    new PointStruct<double>(6, 2)
                )
            );
            Test.Case<float>(
                7.071068f,
                GetDistStructFloatNoSquare(
                    new PointStruct<float>(-1, 3),
                    new PointStruct<float>(6, 2)
                )
            );
            Console.WriteLine("^ По каким-то причинам способ из методички работает не точно.\n");
            
            BenchmarkSwitcher.FromAssembly(typeof(Task3_1).Assembly).Run(args);
        }
    }
}