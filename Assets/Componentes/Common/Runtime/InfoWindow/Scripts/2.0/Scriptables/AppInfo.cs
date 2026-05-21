using System.Collections.Generic;
using UnityEngine;

namespace VP.Common.InfoWindow
{
    [CreateAssetMenu(fileName = "New AppInfo Asset", menuName = "ScriptableObjects/Login/New App Info", order = 0)]
    public class AppInfo : ScriptableObject
    {
        public string title;

        [Tooltip("Se recomienda que el sprite tenga una resolucion similar a 915x305")]
        public Sprite banner;

        [TextArea(5, 30, order = 1)]
        public string description;


        [Header("Creditos")]
        public DepartmentInfo coordinador = new DepartmentInfo { departmentType = Department.Coordinador, row = 0, displayName = "Coordinador"};
        public DepartmentInfo contenido_e_investigacion = new DepartmentInfo { departmentType = Department.Contenido_e_investigacion, row = 0,displayName = "Contenido e investigación"};
        public DepartmentInfo diagramacion_e_ilustracion = new DepartmentInfo { departmentType = Department.Diagramacion_e_ilustracion, row = 0,displayName = "Diagramación e ilustración" };
        public DepartmentInfo diseno_3D = new DepartmentInfo { departmentType = Department.Diseno_3D, row = 0,displayName = "Diseño 3D" };
        public DepartmentInfo desarollo_y_Programacion = new DepartmentInfo { departmentType = Department.Desarollo_y_Programacion, row = 1,displayName = "Desarrollo y Programación" };
        public DepartmentInfo diseno_UX = new DepartmentInfo { departmentType = Department.Diseno_UX, row = 1,displayName = "Diseño UX" };
    }
}