
using UnityEngine;
using System.Collections.Generic;

namespace VpSerializableData
{
    [System.Serializable]
    public class ExcelPage
    {
        public List<string> A;

        public List<string> B;

        public List<string> C;

        public List<string> D;

        public List<string> E;

        public List<string> F;

        public List<string> G;

        public List<string> H;

        public List<string> I;

        public List<string> J;

        public List<string> K;

        public List<string> L;

        public List<string> M;

        public List<string> N;

        public List<string> O;

        public List<string> P;

        public List<string> Q;

        public ExcelPage()
        {
            C = new List<string>(new string[31]);
            D = new List<string>(new string[31]);
            E = new List<string>(new string[31]);
            F = new List<string>(new string[31]);
            G = new List<string>(new string[31]);
            H = new List<string>(new string[31]);
            I = new List<string>(new string[70]);
            J = new List<string>(new string[55]);
            K = new List<string>(new string[55]);
            L = new List<string>(new string[55]);
            M = new List<string>(new string[55]);
        }
    }
}


