using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPost.Models
{
    internal class CollectiveEvent
    {
        public int Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime DateOfEvent { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<User> Participants { get; set; } = new List<User>();

        public int CurrentNumberPerson { get { return Participants.Count(); } }

        public int NecessaryNumberPerson { get; set; }

        public CollectiveEvent()
        {
            DateOfCreation = DateTime.Now;
        }

        public bool isEventHappen()
        {
            return CurrentNumberPerson >= NecessaryNumberPerson;
        }

        public void AddParticipant(User participant)
        {
            Participants.Add(participant);
        }

        public override string ToString()
        {
            string isHappen;
            if (isEventHappen())
            {
                isHappen = "happen";
            }
            else
            {
                isHappen = "not happen";
            }
            return $"event {Title}, {isHappen}, dateEvent: {DateOfEvent.Date.ToString("dd/MM/yyyy")}, participantsId: {String.Join(" ", Participants.Select(participant => participant.Id.ToString()).ToList())}";
        }
    }
}
