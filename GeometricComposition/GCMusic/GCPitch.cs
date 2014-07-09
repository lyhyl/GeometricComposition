namespace GeometricComposition.GCMusic
{
    public enum GCPitch
    {
        C = 0, CS_Db,
        D, DS_Eb,
        E,
        F, FS_Gb,
        G, GS_Ab,
        A, AS_Bb,
        B
    }
    public static class GCPitchHelper
    {
        public static string GetName(GCPitch e)
        {
            switch (e)
            {
                case GCPitch.C:             return "C";
                case GCPitch.CS_Db:     return "C#/Db";
                case GCPitch.D:             return "D";
                case GCPitch.DS_Eb:     return "D#/Eb";
                case GCPitch.E:             return "E";
                case GCPitch.F:             return "F";
                case GCPitch.FS_Gb:     return "F#/Gb";
                case GCPitch.G:             return "G";
                case GCPitch.GS_Ab:     return "G#/Ab";
                case GCPitch.A:             return "A";
                case GCPitch.AS_Bb:     return "A#/Bb";
                case GCPitch.B:             return "B";
                default:                         return "Unknown";
            }
        }
    }
}
