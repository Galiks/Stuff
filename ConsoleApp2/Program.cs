using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp2
{
    abstract class Transport
    {

    }

    class Car:Transport
    {

    }

    class Juguli:Car
    {

    }

    class Lamborgini:Car
    {

    }

    interface IConteinerCovar<out T>
        where T: Transport
    {

    }

    interface IConteinerContr<in T>
        where T: Transport
    {

    }

    interface ITest
    {
        void Move1(int t);
    }

    abstract class Test
    {
        public abstract int x { get; set; }

        public abstract void Move2();

      

        public void Moveing(int t)
        {
            Console.WriteLine("Move");
        }
    }

    class Hero : Test, ITest
    {
        public override int x
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override void Move2()
        {
            throw new NotImplementedException();
        }

        public void Move1(int t)
        {
            throw new NotImplementedException();
        }
    }


    class Conteiner<t>:
        IConteinerContr<t>, IConteinerCovar<t>
        where t: Transport
    {

    }

    class Device
    {
        public  void PressKey() { Console.WriteLine("Device"); }
    }

    class Keyboard:Device
    {
        public new void PressKey()
        {
            Console.WriteLine("Keyboard");
        }

        public int PressKey(char a) { Console.WriteLine($"Keyboard: {a}"); return 0; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //IConteinerCovar<Transport> q1 = new Conteiner<Juguli>();

            //IConteinerContr<Lamborgini> q2 = new Conteiner<Transport>();

            Device k = new Keyboard();
            k.PressKey();
        }
    }
}
