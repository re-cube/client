using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Class
{
    public class Way
    {
        public Transform Transform;
        public Vector3 FromPosition;
        public Vector3 ToPosition;
        public Way(Transform transform, Vector3 fromPosition, Vector3 toPosition)
        {
            Transform = transform;
            FromPosition = fromPosition;
            ToPosition = toPosition;
        }
    }
}
