using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class Arduino_Initial : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("/dev/cu.usbmodem21101", 9600);

    public static int valueStack;

    public static int vol_Value1;
    public static int vib_Value2;
    public static int tou_Value3;

    // Use this for initialization
    void Start()
    {
        OpenConnection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // print(UnityReadData());
        try
        {
            //value = int.Parse(sp.ReadLine());

            string[] valueStack = sp.ReadLine().Split(',');
            vol_Value1 = int.Parse(valueStack[0]);
            vib_Value2 = int.Parse(valueStack[1]);
            tou_Value3 = int.Parse(valueStack[2]);

            //print(valueStack[0] + " " + valueStack[1] + " " + valueStack[2]);

        }
        catch (System.Exception) { }

    }

    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                sp.Open(); // opens the connection
                sp.ReadTimeout = 1; //sets the timeout value before reporting error
                print("Port Opend!");
            }
        }
        else
        {
            if (sp.IsOpen)
                print("Port is already open");
            else
                print("Port == null");
        }
    }

    void OnApplicationQuit()
    {
        sp.Close();
    }

    public static void UnitySendData(string m)
    {
        sp.Write(m);
    }

    /* public static string UnityReadData()
     {
         string me;
         try
         {
             return(sp.ReadLine());
         }catch(System.Exception){ return "0"; }

         //return me;
     }*/

}

