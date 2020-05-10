using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Request
    {
        public AcademicProductivity academicProductivity { get; set; }
        public DateTime DateRequest { get; set; }
        public string State { get; protected set; }
        public decimal AssignedPoints { get; protected set; }
        public decimal EstimatedPoints { get; set; }

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
