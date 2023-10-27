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

            // Register event handlers for program exit
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            // Your main program logic goes here

        }
        catch (Exception e)
        {
            Console.WriteLine("Cannot connect to port: " + myPort.PortName);
            Console.WriteLine(e.ToString());

            // Close the port to release resources
            if (myPort != null && myPort.IsOpen)
            {
                myPort.Close();
            }

            Console.ReadKey(true);
        }
    }

    private static void OnProcessExit(object sender, EventArgs e)
    {
        // This is called when the process is exiting
        CloseSerialPort();
    }

    private static void CloseSerialPort()
    {
        if (myPort != null && myPort.IsOpen)
        {
            myPort.Close();
            Console.WriteLine("Serial port closed.");
        }
    }

    public static void ArduinoWriteLine(int val1, int val2, int val3, int val4, int val5)
    {
        try
        {
            if (myPort != null && myPort.IsOpen)
            {
                string dataSend = $"{val1} {val2} {val3} {val4} {val5}";
                myPort.WriteLine(dataSend);
            }
            else
            {
                Console.WriteLine("Serial port is not open or initialized.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to Arduino: " + ex.Message);
        }
    }
} //Class
