import 'package:all_layouts_app/shared/menu_drawer.dart';
import 'package:flutter/material.dart';

class FourthLayout extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Rows and columns',
      home: Scaffold(           
        drawer: MenuDrawer(),
        appBar: AppBar(
          title: Text('Rows and columns'),
        ),
        backgroundColor: Colors.indigo[100],
        body:  Home(),
      ),
    );
  }
}

class Home extends StatelessWidget {
  const Home({super.key});

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
       Row(children: createSquares(5),
        //mainAxisAlignment: MainAxisAlignment.center,
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        textDirection: TextDirection.rtl,
        crossAxisAlignment: CrossAxisAlignment.center,
      )
    );
  }
  

  List<Widget> createSquares(int numSquares){
    int i  = 0;
    List colors = [Colors.amber, Colors.deepPurple, Colors.deepOrange, Colors.indigo, Colors.lightBlue ];
    List<Widget> squares = [];

    while (i < numSquares){
      // Container square = Container(
      //   color: colors[i],
      //   width: 60,
      //   height: 60,
      //   child: Text(i.toString()),
      // );
      Expanded square = Expanded(
        flex: i,          
        child: Container(
          color: colors[i],
          //width: 60,
          height: 60,
          child: Text(i.toString()),
        )
      );
      i++;
      squares.add(square);
    }

    return squares;
  }
}