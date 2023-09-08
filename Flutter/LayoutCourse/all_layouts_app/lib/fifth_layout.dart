import 'package:all_layouts_app/shared/menu_drawer.dart';
import 'package:flutter/material.dart';

class FifthLayout extends StatelessWidget {
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
        body:  Home_5(),
      ),
    );
  }
}

class Home_5 extends StatelessWidget {
  const Home_5({super.key});

  @override

  Widget build(BuildContext context) {
    final sizeX = MediaQuery.of(context).size.width;
    final sizeY = MediaQuery.of(context).size.height;

    return Container(
      width: sizeX,
      height: sizeY,
      //child: Column(children: createSquares(5),)
      child:/* Column(children: createSquares(5),
        //mainAxisAlignment: MainAxisAlignment.center,
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        verticalDirection: VerticalDirection.up,
        crossAxisAlignment: CrossAxisAlignment.center,
      )*/
       Stack(children: createSquares(5),
        //mainAxisAlignment: MainAxisAlignment.center,
        //textDirection: TextDirection.rtl,
      )
    );
  }
  

  List<Widget> createSquares(int numSquares){
    int i  = 0;
    List colors = [Colors.amber, Colors.deepPurple, Colors.deepOrange, Colors.indigo, Colors.lightBlue ];
    List<Widget> squares = [];

    while (i < numSquares){
      // Container square = Container(        
      //     color: colors[i],
      //     height: 60.0 * (numSquares - i),
      //     width: 50.0 * (numSquares - i),
      //     child: Text(i.toString()),
      // );

      // Align square = Align(
      //   //alignment: Alignment.bottomLeft,
      //   child: Container(        
      //     color: colors[i],
      //     height: 60.0 * (numSquares - i),
      //     width: 50.0 * (numSquares - i),
      //     child: Text(i.toString()),
      // ));

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
}