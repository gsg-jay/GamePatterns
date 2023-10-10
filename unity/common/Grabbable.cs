using UnityEngine;
using System;

namespace GSG
{
    public class Grabbable
    {
        public enum GRAB_TYPE { };
        public enum THROW_TYPE { };

        public UnityEvent<int> OnGrabbed;
        public UnityEvent<int> OnThrown;

        public void HandleGetGrabbed(GRAB_TYPE grabType)
        {
            throw new NotImplementedException("Grabbable::HandleGetGrabbed not implemented!");
        }
        public void HandleGetThrown(GRAB_TYPE throwType)
        {
            throw new NotImplementedException("Grabbable::HandleGetThrown not implemented!");
        }

    }
}