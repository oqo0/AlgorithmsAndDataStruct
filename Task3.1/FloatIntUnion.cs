using System.Runtime.InteropServices;

namespace Task3_1;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
public struct FloatIntUnion
{
    [FieldOffset(0)]
    public int i;
    [FieldOffset(0)]
    public float f;
}