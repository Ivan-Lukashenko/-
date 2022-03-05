using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Тестовое_задание_на_MVC.Models
{
    public class LinkedListMetods
    {
        public void Mes(int dozens, LinkedList<string> linkedList1, LinkedList<string> linkedList2, LinkedList<string> linkedList3)
        {
            int elementFirstList = 0;
            int elementSecondtList = 0;

            if (linkedList1.Count != 0)
            {
                elementFirstList = int.Parse(linkedList1.LastOrDefault());
                linkedList1.RemoveLast();
            }

            if (linkedList2.Count != 0)
            {
                elementSecondtList = int.Parse(linkedList2.LastOrDefault());
                linkedList2.RemoveLast();
            }
            var sum = elementFirstList + elementSecondtList + dozens;
            if (sum >= 10)
            {
                var max = sum;
                sum = sum % 10;
                dozens = (max - sum) / 10;
            }
            else
            {
                dozens = 0;
            }
            linkedList3.AddLast(sum.ToString());
            if (linkedList1.Count != 0 || linkedList2.Count != 0)
            {
                Mes(dozens, linkedList1, linkedList2, linkedList3);
            }
        }
    }
}
