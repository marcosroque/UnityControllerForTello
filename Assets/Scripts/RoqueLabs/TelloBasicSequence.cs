using System.Collections;
using System.Collections.Generic;
using TelloLib;
using UnityEngine;

namespace UnityControllerForTello
{
    public class TelloBasicSequence : MonoBehaviour
    {
        public void StartDemo()
        {
            StartCoroutine(DemoMovements());
        }

        IEnumerator DemoMovements()
        {
            Debug.Log("+++ DemoMovements Start");

            yield return new WaitForSeconds(0.5f);
            SendCommand("command");

            yield return new WaitForSeconds(3f);
            SendCommand("mon");

            yield return new WaitForSeconds(1f);
            SendCommand("battery?");

            //yield return new WaitForSeconds(1.5f);
            //SendCommand("takeoff");

            // MISSION PADS COMMANDS
            /*yield return new WaitForSeconds(3f);
            SendCommand("mon");
            yield return new WaitForSeconds(3f);
            SendCommand("mdirection 0");
            yield return new WaitForSeconds(3f);
            SendCommand("go 0 0 100 30 m1");
            yield return new WaitForSeconds(3f);
            SendCommand("go 0 0 130 60 m3");
            yield return new WaitForSeconds(3f);
            SendCommand("go 0 0 80 30 m5");
            yield return new WaitForSeconds(3f);
            SendCommand("go -40 0 50 30 m3");
            yield return new WaitForSeconds(3f);
            SendCommand("jump 0 0 100 60 90 m1 m3");*/

            // ELEVATION COMMANDS
            /*yield return new WaitForSeconds(3f);
            SendCommand("up 20");
            yield return new WaitForSeconds(3f);
            SendCommand("down 20");
            yield return new WaitForSeconds(3f);
            SendCommand("up 80");
            yield return new WaitForSeconds(4f);
            SendCommand("down 30");*/

            // PHOTO COMMANDS
            yield return new WaitForSeconds(3f);
            Tello.takePicture();

            // SIDE COMMANDS
            /*yield return new WaitForSeconds(3f);
            SendCommand("left 30");
            yield return new WaitForSeconds(3f);
            SendCommand("forward 30");
            yield return new WaitForSeconds(3f);
            SendCommand("right 30");
            yield return new WaitForSeconds(3f);
            SendCommand("back 30");*/

            // REVOLVE COMMANDS
            /*yield return new WaitForSeconds(3f);
            SendCommand("cw 90");
            yield return new WaitForSeconds(3f);
            SendCommand("ccw 180");
            yield return new WaitForSeconds(5f);
            SendCommand("cw 90");
            yield return new WaitForSeconds(3f);
            SendCommand("flip r");
            yield return new WaitForSeconds(3f);
            SendCommand("flip l");*/

            //yield return new WaitForSeconds(3f);
            //SendCommand("land");

            Debug.Log("--- DemoMovements End");
        }

        private void SendCommand(string command)
        {
            Debug.Log("SendCommand: " + command);
            Tello.SendStringMessage(command);
        }
    }
}
