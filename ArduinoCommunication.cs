using System;
using System.IO.Ports;

class ArduinoCommunication
{
    private static SerialPort myPort;

    public static void ArduinoConnection()
    {
        try
        {
            myPort = new SerialPort("COM3", 128000, Parity.None, 8, StopBits.One);
            myPort.Open();
            Console.WriteLine("Connected on port number: " + myPort.PortName);
            // Additional initialization or configuration if needed

            // Your main program loop goes here
            while (true)
            {
                // Check for user input
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.X)
                    {
                        CloseSerialPort();
                        break; // Exit the loop when 'X' is pressed
                    }
                }

                // Your other program logic goes here
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Cannot connect to port: " + myPort.PortName);
            Console.WriteLine(e.ToString());

            // Close the port to release resources
            CloseSerialPort();
        }
    }

    private static void CloseSerialPort()
    {
        if (myPort != null && myPort.IsOpen)
        {
            myPort.Close();
            Console.WriteLine("Serial port closed.");
        }
    }
}
