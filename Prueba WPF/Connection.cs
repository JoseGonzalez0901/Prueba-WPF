using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_WPF
{
    public class Connection
    {
        static SerialPort Serial;
        public Connection()
        {
            Serial = new SerialPort();  
        }
        public static void Connect(string portName)
        {
            Serial = new SerialPort(portName, 9600)
            {
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None
            };
            Serial.DataReceived += SerialDataReceivedHandler;
            Serial.Open();
        }
        public static void Disconnect()
        {
            if (Serial != null && Serial.IsOpen)
            {
                Serial.Close();
                Serial.Dispose();
                Serial = null;
            }
        }
        public void SendData(string data)
        {
            if (Serial != null && Serial.IsOpen)
            {
                Serial.WriteLine(data);
            }
        }
        public static string ReadData()
        {
            if (Serial != null && Serial.IsOpen)
            {
                return Serial.ReadLine();
            }
            return null;
        }
        public static string[] GetAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }
        public static bool IsPortAvailable(string portName)
        {
            return SerialPort.GetPortNames().Contains(portName);
        }
        public static void Dispose()
        {
            if (Serial != null)
            {
                Serial.Dispose();
                Serial = null;
            }
        }
        public static void SetPortName(string portName)
        {
            if (Serial != null)
            {
                Serial.PortName = portName;
            }
        }
        public static string GetPortName()
        {
            if (Serial != null)
            {
                return Serial.PortName;
            }
            return null;
        }
        public static void SetBaudRate(int baudRate)
        {
            if (Serial != null)
            {
                Serial.BaudRate = baudRate;
            }
        }
        public static int GetBaudRate()
        {
            if (Serial != null)
            {
                return Serial.BaudRate;
            }
            return 0;
        }
        public static void SetDataBits(int dataBits)
        {
            if (Serial != null)
            {
                Serial.DataBits = dataBits;
            }
        }
        public static int GetDataBits()
        {
            if (Serial != null)
            {
                return Serial.DataBits;
            }
            return 0;
        }
        public static void SetParity(Parity parity)
        {
            if (Serial != null)
            {
                Serial.Parity = parity;
            }
        }
        public static Parity GetParity()
        {
            if (Serial != null)
            {
                return Serial.Parity;
            }
            return Parity.None;
        }
        public static void SetStopBits(StopBits stopBits)
        {
            if (Serial != null)
            {
                Serial.StopBits = stopBits;
            }
        }
        public static StopBits GetStopBits()
        {
            if (Serial != null)
            {
                return Serial.StopBits;
            }
            return StopBits.None;
        }
        public static void SetHandshake(Handshake handshake)
        {
            if (Serial != null)
            {
                Serial.Handshake = handshake;
            }
        }
        public static Handshake GetHandshake()
        {
            if (Serial != null)
            {
                return Serial.Handshake;
            }
            return Handshake.None;
        }
        public static void SetReadTimeout(int timeout)
        {
            if (Serial != null)
            {
                Serial.ReadTimeout = timeout;
            }
        }
        public static int GetReadTimeout()
        {
            if (Serial != null)
            {
                return Serial.ReadTimeout;
            }
            return 0;
        }
        public static void SetWriteTimeout(int timeout)
        {
            if (Serial != null)
            {
                Serial.WriteTimeout = timeout;
            }
        }
        public static int GetWriteTimeout()
        {
            if (Serial != null)
            {
                return Serial.WriteTimeout;
            }
            return 0;
        }
        public static void SetDtrEnable(bool enable)
        {
            if (Serial != null)
            {
                Serial.DtrEnable = enable;
            }
        }
        public static bool GetDtrEnable()
        {
            if (Serial != null)
            {
                return Serial.DtrEnable;
            }
            return false;
        }
        public static void SetRtsEnable(bool enable)
        {
            if (Serial != null)
            {
                Serial.RtsEnable = enable;
            }
        }
        public static bool GetRtsEnable()
        {
            if (Serial != null)
            {
                return Serial.RtsEnable;
            }
            return false;
        }
        public static void SetDiscardNull(bool discardNull)
        {
            if (Serial != null)
            {
                Serial.DiscardNull = discardNull;
            }
        }
        public static bool GetDiscardNull()
        {
            if (Serial != null)
            {
                return Serial.DiscardNull;
            }
            return false;
        }
        public static void SetNewLine(string newLine)
        {
            if (Serial != null)
            {
                Serial.NewLine = newLine;
            }
        }
        public static string GetNewLine()
        {
            if (Serial != null)
            {
                return Serial.NewLine;
            }
            return null;
        }
        private static void SerialDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string received = Serial.ReadLine(); // o ReadLine() si esperas texto terminado en \n
                Console.WriteLine($"[RX] {received}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer datos: " + ex.Message);
            }
        }
    }
}
