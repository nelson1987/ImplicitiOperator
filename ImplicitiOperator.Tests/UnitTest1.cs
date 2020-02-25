using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ImplicitiOperator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Aluno marcio = new Aluno(1, "Marcio Silva", "123.456.789-01");
            AlunoDTO alunoDto = marcio;

        }
    }
    public class AlunoDTO
    {
        public AlunoDTO(int id, string nome, string matricula)
        {
            Id = id;
            Nome = nome;
            Matricula = matricula;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Matricula { get; private set; }
        public override string ToString()
        {
            return string.Format("O aluno {0}, tem a matrícula {1}", Nome, Matricula);
        }
    }
    public class Aluno
    {
        public Aluno(int id, string nome, string matricula)
        {
            Id = id;
            Nome = nome;
            Matricula = matricula;
        }

        public virtual int Id { get; private set; }
        public virtual string Nome { get; private set; }
        public virtual string Matricula { get; private set; }

        public static implicit operator AlunoDTO(Aluno d)
        {
            return new AlunoDTO(d.Id, d.Nome, d.Matricula);
        }
    }
    public struct Digit
    {
        private readonly byte digit;

        public Digit(byte digit)
        {
            if (digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Digit cannot be greater than nine.");
            }
            this.digit = digit;
        }

        public static implicit operator byte(Digit d) => d.digit;
        public static explicit operator Digit(byte b) => new Digit(b);

        public override string ToString() => $"{digit}";
    }
}
