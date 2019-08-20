using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TelloLib;
using UnityEngine;

namespace RoqueLabs
{
    public class TelloBasicSequence : MonoBehaviour
    {
        private bool demoRunning;
        public void StartDemo()
        {
            if (!demoRunning)
            {
                demoRunning = true;
                StartCoroutine(DemoMovements());
            }
            else
            {
                demoRunning = false;
                StopAllCoroutines();
                TelloRawConnection.Disconnect();
            }
        }

        IEnumerator DemoMovements()
        {
            Debug.Log("+++ DemoMovements Start");

            yield return new WaitForSeconds(0.5f);SendCommand("command");

            //yield return new WaitForSeconds(1.5f); SendCommand("takeoff");

            yield return new WaitForSeconds(1f); SendCommand("battery?");

            // ELEVATION COMMANDS
            /*yield return new WaitForSeconds(3f);
            SendCommand("up 20");
            yield return new WaitForSeconds(3f);
            SendCommand("down 20");
            yield return new WaitForSeconds(3f);
            SendCommand("up 80");*/
            //yield return new WaitForSeconds(4f);SendCommand("down 30");

            // PHOTO COMMANDS
            //yield return new WaitForSeconds(3f);
            //Tello.takePicture();

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

            yield return new WaitForSeconds(1f); SendCommand("land");

            Debug.Log("--- DemoMovements End");
        }

        private void SendCommand(string command)
        {
            Debug.Log("SendCommand: " + command);
            //Tello.SendStringMessage(command);
            TelloRawConnection.Send(command);
        }
    }
}
