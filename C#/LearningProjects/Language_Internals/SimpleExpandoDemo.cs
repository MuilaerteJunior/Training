using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Language_Internals {
    class Program {
        static void Main(string[] args) {

            dynamic person = new Expando();

            person.Name = "Mui";

            string name = person.Name;

            Console.WriteLine(name);
        }
    }

    class Expando : DynamicObject {
        private Dictionary<string, object> _items = new Dictionary<string, object>();

        public override IEnumerable<string> GetDynamicMemberNames() {
            return _items.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            return _items.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value) {

            _items[binder.Name] = value;
            return true;
        }
    }
}
