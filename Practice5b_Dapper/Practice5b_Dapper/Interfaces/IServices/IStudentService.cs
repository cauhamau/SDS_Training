﻿using Practice5b_Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5b_Dapper.Interfaces.IServices
{
    internal interface IStudentService
    {
        List<Student> GetAll();

        void ShowList(List<Student> student);

        void ShowStudent(List<Student> student);

        void CountSubjects(List<Student> students);

        void ShowEnrolledCourseInfoForStudent(List<Student> students);

        void ShowResultStudent(List<Student> students);

        void InputScore(List<Student> students);
    }
}
