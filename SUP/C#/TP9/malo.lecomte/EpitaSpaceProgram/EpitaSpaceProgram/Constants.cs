namespace EpitaSpaceProgram
{
    public static class Constants
    {
        // Which port should the server listen on.
        public const int Port = 42042;

        // How many times per second should we update the simulation (Hertz).
        // The bigger this number is, the more precise the simulation will be, and the more taxing it will be on your computer.
        public const long RefreshRate = 60;
    }
}