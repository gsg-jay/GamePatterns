using UnityEngine;
using System;

namespace GSG
{
    public interface IGrabbable
    {
        public enum GRAB_TYPE { };          // TODO Extract to own class
        public enum THROW_TYPE { };         // TODO Extract to own class

        public UnityEvent<int> OnGrabbed;
        public UnityEvent<int> OnThrown;

        public virtual void HandleGetGrabbed(GRAB_TYPE grabType)
        {
            throw new NotImplementedException("Grabbable::HandleGetGrabbed not implemented!");
        }
        public virtual void HandleGetThrown(GRAB_TYPE throwType)
        {
            throw new NotImplementedException("Grabbable::HandleGetThrown not implemented!");
        }
    }
}