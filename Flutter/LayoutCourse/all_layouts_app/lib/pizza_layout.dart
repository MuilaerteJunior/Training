import 'package:all_layouts_app/shared/menu_drawer.dart';
import 'package:flutter/material.dart';

class PizzaLayout extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Stack',
      home: Scaffold(           
        drawer: MenuDrawer(),
        appBar: AppBar(
          title: Text('Stack'),
        ),
        backgroundColor: Colors.indigo[100],
        body:  PizzaLayoutHome(),
      ),
    );
  }
}

class PizzaLayoutHome extends StatelessWidget {
  const PizzaLayoutHome({super.key});

  @override

  Widget build(BuildContext context) {
    final sizeX = MediaQuery.of(context).size.width;
    final sizeY = MediaQuery.of(context).size.height;

    return Container(
      width: sizeX,
      height: sizeY,
      child: Stack(children: createPizzaLayout2(sizeX, sizeY))
    );
  }
  
  List<Widget> createSquares(int numSquares){
    int i  = 0;
    List colors = [Colors.amber, Colors.deepPurple, Colors.deepOrange, Colors.indigo, Colors.lightBlue ];
    List<Widget> squares = [];

    while (i < numSquares){
      Positioned square = Positioned(
        top: 100 + i.toDouble() * 100,
        left: 25 + i.toDouble() * 25,
        child: Container(        
          color: colors[i],
          height: 60.0 * (numSquares - i),
          width: 50.0 * (numSquares - i),
          child: Text(i.toString()),
      ));

      i++;
      squares.add(square);
    }

    return squares;
  }

  ///My version
  List<Widget> createPizzaLayout(){    
    List<Widget> squares = [];    
    Positioned pizza = Positioned(
      top: 50,
      left: 200,  
      //color: Colors.black,
      child: Stack(
        children:[ 
          Container( 
            color: Colors.grey,     
            child: Container(          
              color : Colors.grey,
              child: Text("This delicious pizza is made of Tomato, Mozzarella and Basil.\r\n\r\nSeriously you can't miss it." ),
              margin: EdgeInsets.all(20)
            )
          ),
          Align(
            alignment: Alignment.center,
            child:Container( 
              color: Colors.blue, 
              width: 300,
              //width: max,    
              child: Text("Pizza Margherita", textAlign: TextAlign.center),
            )
          ),
        ]
      )
    );

    Positioned orderButton = Positioned(
      bottom: 20,
      left: 200,  
      child: Container( 
        color: Colors.green,
        child: Text('Order now!'),
      )
    );

    squares.add(pizza);
    squares.add(orderButton);
    return squares;
  }

  List<Widget> createPizzaLayout2(double sizeX, double sizeY){    
    List<Widget> layoutChildren = [];
    Container background = Container(
      decoration: 
        BoxDecoration(
          image: DecorationImage(
            image: NetworkImage('https://images.freeimages.com/images/large-previews/e85/pizza-1325642.jpg'),
            fit: BoxFit.fitHeight
          )
        ),
    );
       
    Positioned pizzaCard = Positioned(      
      top: sizeY/20,
      left: sizeX/20,
      right: sizeX/20,
      child: Card(
        elevation: 12,        
        color: Colors.white70,        
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
        child: Column(          
          children: [
            Text("Pizza Margherita", style: TextStyle(fontSize: 24, fontWeight:  FontWeight.bold, color: Colors.deepOrange[800])),
            Padding(
              padding: EdgeInsets.all(12),
              child: Text('This delicious pizza is made of blahblahblah.\n\nThanks!!', style: TextStyle(fontSize: 18, color: Colors.grey[800]))
            )
          ],)
      )
    );

    Positioned buttonOrder = Positioned(
      bottom: sizeY /20,
      left : sizeX / 20,
      width: sizeX - sizeX/10,
      child: ElevatedButton(
        style: ElevatedButton.styleFrom(elevation: 12, shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(8)), backgroundColor: Colors.orange[900]),
        //color: Colors.orange[900],
        child: Text('Order Now!', style: TextStyle(fontSize: 20, color: Colors.white)),
        onPressed: () {},
      )
    );

    layoutChildren.add(background);
    layoutChildren.add(pizzaCard);
    layoutChildren.add(buttonOrder);
    return layoutChildren;
  }
}