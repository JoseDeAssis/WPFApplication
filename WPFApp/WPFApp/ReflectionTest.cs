using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFApp {

    class Student {

        public Student(int age, string name, string school) {
            this.age = age;
            this.name = name;
            this.school = school;
        }

        public int age { get; set; }
        public string name { get; set; }
        public string school { get; set; }

        /*public void study(int hour) {
            MessageBox.Show(this.name + " studies " + hour + " per day");
        }

        public void sleep() {
            MessageBox.Show(this.name + " is sleeping");
        }*/

    }

    class ReflectionTest {
        public static void runReflection() {
            createObject();
        }

        public static void createObject() {
            Type type = typeof(Student);
            //Type type = typeof("WPFApp.Student");

            Object newStudent = Activator.CreateInstance(type, new object[] {24, "Zé Maria", "UFC"});

            PropertyInfo[] properties = type.GetProperties();

            /*foreach (PropertyInfo property in properties) {
                MessageBox.Show(property.Name.ToString());
            }*/

            PropertyInfo age = type.GetProperty("age");

            //MessageBox.Show(age.GetValue(newStudent).ToString());

            age.SetValue(newStudent, 34);

            //MessageBox.Show(age.GetValue(newStudent).ToString());

            MethodInfo[] methods = type.GetMethods();

            /*foreach (var method in methods) {
                MessageBox.Show(method.Name.ToString());
            }*/
/*
            type.InvokeMember("sleep", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null,
                newStudent, null);
            type.InvokeMember("study", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null,
                newStudent, new object[] {10});*/
        }
    }
}
