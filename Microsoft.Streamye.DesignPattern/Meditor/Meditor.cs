using System.Collections.Generic;
using Microsoft.Streamye.DesignPattern.Meditor.Group;

namespace Microsoft.Streamye.DesignPattern.Meditor
{
    public class Meditor
    {
        private IList<IPeople> _list = new List<IPeople>();

        public void AddPeople(IPeople people)
        {
            _list.Add(people);
        }
        
        public void Send(string message)
        {
            // send messge 给每一个人
            foreach (var people in _list)
            {
                people.Receive(message);
            }
        }
    }
}