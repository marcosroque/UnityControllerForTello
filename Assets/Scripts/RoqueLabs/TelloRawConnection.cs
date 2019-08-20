using System;
using System.Threading;
using System.Threading.Tasks;
using TelloLib;
using UnityEngine;

namespace RoqueLabs
{
    public class TelloRawConnection : MonoBehaviour
    {
        private static UdpUser client;
        private static CancellationTokenSource cancelTokens = new CancellationTokenSource();

        private CancellationToken token;

        private Received receivedState, receivedClient;
        private UdpListener stateListener;

        void Start()
        {
            client = UdpUser.ConnectTo("192.168.10.1", 8889);

            CancellationToken token = cancelTokens.Token;

            DeviceStateListeners();
            CommandsResponseListeners();
        }

        internal static void Disconnect()
        {
            Debug.Log("Disconnect");
            client.Client.Close();
            cancelTokens.Cancel();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                GetComponent<TelloBasicSequence>().StartDemo();
            }
        }

        public static void Send(string message)
        {
            client.Send(message);
        }

        private void DeviceStateListeners()
        {
            // Device state
            if (stateListener == null)
                stateListener = new UdpListener(8890);

            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        receivedState = await stateListener.Receive();
                        Debug.Log(string.Format("State response - Message: {0} | Sender: {1} | bytes[]: {2} ", receivedState.Message, receivedState.Sender, receivedState.bytes));
                    }
                    catch (System.Exception ex)
                    {
                        Debug.Log(string.Format("State exception - Message: {0}", ex.Message));
                    }
                }
            }, token);
        }

        public void CommandsResponseListeners()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        receivedClient = await client.Receive();
                        Debug.Log(string.Format("Client response - Message: {0} | Sender: {1} | bytes[]: {2} ", receivedClient.Message, receivedClient.Sender, receivedClient.bytes));
                    }
                    catch (System.Exception ex)
                    {
                        Debug.Log(string.Format("Client exception - Message: {0}", ex.Message));
                    }
                }
            }, token);
        }
    }

}