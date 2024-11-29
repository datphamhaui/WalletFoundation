using System;

namespace Reown.AppKit.Unity.WebGl.Modal
{
    [Serializable]
    public class ModalState
    {
        public bool open;
        public int selectedNetworkId;
    }
    
    [Serializable]
    public class OpenModalParameters
    {
        public string view;
        
        public OpenModalParameters(ViewType view)
        {
            this.view = view.ToString();
        }
    }
    
    public enum ViewType
    {
        Connect,
        Account,
        AllWallets,
        Networks,
        WhatIsANetwork,
        WhatIsAWallet,
        OnRampProviders,
        ConnectingWalletConnect,
        ConnectWallets,
    }
}