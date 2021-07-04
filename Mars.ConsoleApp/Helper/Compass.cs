namespace Mars.ConsoleApp.Helper
{
    public class Compass
    {
        public const string North = "N";
        public const string South = "S";
        public const string West = "W";
        public const string East = "E";

        public static string GetCompassDirection(string compassDirection, string movement)
        {
            return compassDirection switch
            {
                North => GetNorthDirection(movement),
                South => GetSouthDirection(movement),
                West => GetWestDirection(movement),
                East => GetEastDirection(movement),
                _ => string.Empty,
            };
        }

        private static string GetNorthDirection(string movement)
        {
            if (movement == Movement.Right)
            {
                return East;
            }

            return West;
        }

        private static string GetSouthDirection(string movement)
        {
            if (movement == Movement.Right)
            {
                return West;
            }

            return East;
        }

        private static string GetWestDirection(string movement)
        {
            if (movement == Movement.Right)
            {
                return North;
            }

            return South;
        }

        private static string GetEastDirection(string movement)
        {
            if (movement == Movement.Right)
            {
                return South;
            }

            return North;
        }

    }
}
