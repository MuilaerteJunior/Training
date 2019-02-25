using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Internals {
    class Program {
        static void Main(string[] args) {
            Bool a = true;
            Bool b = false;

            Bool c = !!a & b;

            //Bool o = new Optimizer().Visit(c);
        }
    }


    class Bool {
        public static implicit operator Bool (bool b) {
            return new Const { Value = b };
        }

        public static Bool operator !(Bool b) {
            return new Not { Operand = b };
        }
        
        public static Bool operator &(Bool a, Bool b) {
            return new And { Left = a, Right = b };
        }
    }

    class Const: Bool {
        public Bool Value { get; set; }
    }
    
    class Not: Bool {
        public Bool Operand { get; set; }
    }
    
    class And: Bool {
        public Bool Left { get; set; }
        public Bool Right { get; set; }
    }

    abstract class BoolVisitor<R> {
        public R Visit(Bool b) {
            var c = b as Const;
            if ( c != null ) {
                return VisitConstant(c);
            }

            var n = b as Not;
            if ( n != null ) {
                return VisitNot(n);
            }

            var a = b as And;
            if ( a != null ) {
                return VisitAnd(a);
            }

            throw new NotSupportedException();
        }

        protected abstract R VisitAnd(And c);
        protected abstract R VisitNot(Not c);
        protected abstract R VisitConstant(Const c);
    }

    class BoolVisitor : BoolVisitor<Bool> {
        protected override Bool VisitAnd(And c) {
            return new And { Left = Visit(c.Left), Right = Visit(c.Right) };
        }

        protected override Bool VisitConstant(Const c) {
            return c;   
        }

        protected override Bool VisitNot(Not c) {
            return new Not { Operand = Visit(c.Operand) };
        }
    }

    class Optimizer : BoolVisitor {
        protected override Bool VisitNot(Not n) {
            if ( n.Operand is Not ) {
                return ((Not) n.Operand).Operand;
            }
            return true;
        }
    }
}
