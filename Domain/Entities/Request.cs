using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Request : Entity<int>
    {
        public AcademicProductivity Productivity { get; set; }
        public DateTime DateRequest { get; set; }
        public string State { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal AssignedPoints { get; protected set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal EstimatedPoints { get; set; }

        public Request()
        {

        }

        public Request(AcademicProductivity productivity)
        {
            Productivity = productivity;
        }

        public void SendRequest()
        {
            EstimatedPoints = Productivity.RequestEvaluate();
            DateRequest = DateTime.Now;
            State = "Enviada";
        }

        public void RequestState(int num)
        {
            if(num == 1)
            {
                State = "Recibido";

            }else if (num == 2)
            {
                State = "Aprobado";
            }
            else if(num == 3)
            {
                State = "Rechazado";
            }
            else
            {
                throw new InvalidOperationException("Estado invalido");
            }
        }

        public void Evaluate(bool acceptEstimatedPoints)
        {
            if(State == "Aprobado")
            {
                if (acceptEstimatedPoints)
                {
                    AssignedPoints = EstimatedPoints;
                    //throw new RequestExeption($"Solicitud evaluada exitosamente, su puntaje asignado es {AssignedPoints}");
                }
                else
                {
                    throw new RequestExeption($"Solicitud evaluada incorrectamente");

                }
            }
            else
            {
                throw new RequestExeption($"La solicitud no puede ser evaluada porque su estado es {State}");
            }

        }

        public void Evaluate(decimal points)
        {
            if (State == "Aprobado")
            {
                if (points > 0)
                {
                    AssignedPoints = EstimatedPoints;
                    throw new InvalidOperationException($"Solicitud evaluada exitosamente, su puntaje asignado es {AssignedPoints}");
                }
                else
                {
                    throw new InvalidOperationException($"Asignacion de puntaje incorrecta, debe ser mayor a 0");
                }

            }
            else
            {
                throw new InvalidOperationException($"La solicitud no puede ser evaluada porque su estado es {State}");
            }
        }

        [Serializable]
        public class RequestExeption : Exception
        {
            public RequestExeption() { }
            public RequestExeption(string message) : base(message) { }
            public RequestExeption(string message, Exception inner) : base(message, inner) { }
            protected RequestExeption(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

    }
}
