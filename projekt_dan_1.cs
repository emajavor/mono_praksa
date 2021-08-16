using System;
using static System.Console;



namespace proba_project
{
	class Student
	{
		static void Main(string[] args)
		{
			Prosjek p = new Prosjek();
			p.Unos_podataka();
			p.Display();
			Console.ReadLine();

			Ema ema = new Ema();
			ema.smjer();

			Stipendist student1 = new Stipendist();
			student1.Student_ID = 1234;
			student1.Ime = "Ema";
			student1.Prezime = "Javor";
			student1.Fakultet = "Odjel za matematiku";
			student1.Mjesecni_iznos = 900;
			student1.Subvencija = 200;


			student1.ECTS(7, 6, 6, 8);
			student1.ECTS(7, 6, 6, 8, 12);
			


			Student student = new Student();
			Ispisi(student1.Student_ID, student1.Puno_ime(), student1.Fakultet, student1.Potpuna_stipendija());

			ReadKey();

			static void Ispisi(int ID, string punoIme, string fakultet, decimal potpuna_stipendija)
			{
				WriteLine("ID studenta: " + ID);
				WriteLine("Ime studenta: " + punoIme);
				WriteLine("Smjer: " + fakultet);
				WriteLine("Iznos godisnje stipendije: " + potpuna_stipendija);

			}
		}

		class Prosjek
		{
			private double predmet1;
			private double predmet2;
			private double predmet3;
			private double predmet4;

			public void Unos_podataka()
			{
				Console.WriteLine("Unesite prosjek prvog predmeta: ");
				predmet1 = Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Unesite prosjek drugog predmeta: ");
				predmet2 = Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Unesite prosjek treceg predmeta: ");
				predmet3 = Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Unesite prosjek cetvrtog predmeta: ");
				predmet4 = Convert.ToDouble(Console.ReadLine());
				Generics<string> genS = new Generics<string>("Poruka iz Generics klase");
				Generics<char> genC = new Generics<char>('G');


			}
			public double Izracunaj_prosjek()
			{
				return (predmet1 + predmet2 + predmet3 + predmet4) / 4;
			}
			public void Display()
			{
				Console.WriteLine("Prosjek 1. predmeta: {0}", predmet1);
				Console.WriteLine("Prosjek 2. predmeta: {0}", predmet2);
				Console.WriteLine("Prosjek 3. predmeta: {0}", predmet3);
				Console.WriteLine("Prosjek 4. predmeta: {0}", predmet4);
				Console.WriteLine("Ukupan prosjek: {0}", Izracunaj_prosjek());
			}
		}

		public abstract class Podaci_studenta
		{
			public int Student_ID { get; set; }
			public string Ime { get; set; }
			public string Prezime { get; set; }
			public string Fakultet { get; set; }

			public string Puno_ime() => Ime + " " + Prezime;

			
			public abstract decimal Potpuna_stipendija();

		}
		class Stipendist : Podaci_studenta
		{
			public decimal Mjesecni_iznos { get; set; }
			public decimal Subvencija { get; set; }
			public string Status { get; } = "Student je stipendist";

			public override decimal Potpuna_stipendija() => (Mjesecni_iznos + Subvencija) * 9;

			public void ECTS(int ects_predmet1, int ects_predmet2, int ects_predmet3, int ects_predmet4)
			{
				Console.WriteLine("zbroj ECTS-a je {0} ", ects_predmet1 + ects_predmet2 + ects_predmet3 + ects_predmet4);
			}
			public void ECTS(int ects_predmet1, int ects_predmet2, int ects_predmet3, int ects_predmet4, int ects_zavrsni_rad)
			{
				Console.WriteLine("zbroj ECTS-a je {0} ", ects_predmet1 + ects_predmet2 + ects_predmet3 + ects_predmet4 + ects_zavrsni_rad);
			}

		}
		class Generics<T>
		{
			public Generics(T poruka)
			{
				Console.WriteLine(poruka);
			}
		}

		interface IEma
		{
			void smjer();
		}

		// Pig "implements" the IAnimal interface
		class Ema : IEma
		{
			public void smjer()
			{
				// The body of animalSound() is provided here
				Console.WriteLine("Emin smjer je Matematika i racunarstvo");
			}
		}
	}
}

