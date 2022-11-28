using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace wpf2022
{
    public class CModelSEE_cszarp
    {
#if RELEASE
        const string dllPath = @"C:\Users\01159502\Desktop\plans2\bin\vs2019\Release\DLLtest.dll";
#else
        const string dllPath = @"C:\Users\01159502\Desktop\plans2\bin\vs2019\debug\DLLtest.dll";
#endif

        [DllImport(dllPath)]
        private static extern IntPtr createModel_cpp();
        [DllImport(dllPath)]
        private static extern int readDataKDM_cpp(IntPtr ptr, string file);
        [DllImport(dllPath)]
        private static extern int N_Nod_cpp(IntPtr ptr);
        [DllImport(dllPath)]
        private static extern int NodTyp_cpp(IntPtr ptr, int id);
        [DllImport(dllPath)]
        private static extern int NodSt_cpp(IntPtr ptr, int id);
        [DllImport(dllPath)]
        private static extern int NodArea_cpp(IntPtr ptr, int id);
        [DllImport(dllPath)]
        private static extern int NodZone_cpp(IntPtr ptr, int id);
        [DllImport(dllPath)]
        private static extern int NodComp_cpp(IntPtr ptr, int id);
        [DllImport(dllPath)]
        private static extern int NodRegn_cpp(IntPtr ptr, int id);
        [DllImport(dllPath)]
        private static extern double NodVs_cpp(IntPtr ptr, int id);
        [DllImport(dllPath)]
        private static extern double NodPl_cpp(IntPtr ptr, int id);

        [DllImport(dllPath)]
        private static extern double NodQl_cpp(IntPtr ptr, int id);

        [DllImport(dllPath)]
        private static extern double NodPg_cpp(IntPtr ptr, int id);

        [DllImport(dllPath)]
        private static extern double NodQg_cpp(IntPtr ptr, int id);

        [DllImport(dllPath)]
        private static extern double NodQmin_cpp(IntPtr ptr, int id);

        [DllImport(dllPath)]
        private static extern double NodQmax_cpp(IntPtr ptr, int id);

        [DllImport(dllPath)]
        private static extern double NodVn_cpp(IntPtr ptr, int id);

        [DllImport(dllPath)]
        private static extern double NodVmin_cpp(IntPtr ptr, int id);

        [DllImport(dllPath)]
        private static extern double NodVmax_cpp(IntPtr ptr, int id);

        [DllImport(dllPath)]
        private static extern double NodVi_cpp(IntPtr ptr, int id);

        [DllImport(dllPath)]
        private static extern double NodDi_cpp(IntPtr ptr, int id);


        private IntPtr ptr;
        public CModelSEE_cszarp()
        {
            ptr = createModel_cpp();
        }

        public CModelSEE_cszarp(IntPtr model)
        {
            this.ptr = model;
        }

        public void Detach()
        {
            ptr = IntPtr.Zero;
        }

        public int readDataKDM(string path)
        {
            if (path == null)
                return -1;
            return readDataKDM_cpp(ptr, path);
        }

        public int N_Nod()
        {
            return N_Nod_cpp(ptr);
        }

        public int NodTyp(int id)
        {
            return NodTyp_cpp(ptr, id);
        }

        public int NodSt(int id)
        {
            return NodSt_cpp(ptr, id);
        }

        public int NodArea(int id)
        {
            return NodArea_cpp(ptr, id);
        }
        public int NodZone(int id)
        {
            return NodZone_cpp(ptr, id);
        }

        public int NodComp(int id)
        {
            return NodComp_cpp(ptr, id);
        }

        public int NodRegn(int id)
        {
            return NodRegn_cpp(ptr, id);
        }

        public double NodVs(int id)
        {
            return NodVs_cpp(ptr, id);
        }
        public double NodPl(int id)
        {
            return NodPl_cpp(ptr, id);
        }
        public double NodQl(int id)
        {
            return NodQl_cpp(ptr, id);
        }
        public double NodPg(int id)
        {
            return NodPg_cpp(ptr, id);
        }
        public double NodQg(int id)
        {
            return NodQg_cpp(ptr, id);
        }
        public double NodQmin(int id)
        {
            return NodQmin_cpp(ptr, id);
        }
        public double NodQmax(int id)
        {
            return NodQmax_cpp(ptr, id);
        }
        public double NodVn(int id)
        {
            return NodVn_cpp(ptr, id);
        }
        public double NodVmin(int id)
        {
            return NodVmin_cpp(ptr, id);
        }
        public double NodVmax(int id)
        {
            return NodVmax_cpp(ptr, id);
        }
        public double NodVi(int id)
        {
            return NodVi_cpp(ptr, id);
        }
        public double NodDi(int id)
        {
            return NodDi_cpp(ptr, id);
        }
    }
}
