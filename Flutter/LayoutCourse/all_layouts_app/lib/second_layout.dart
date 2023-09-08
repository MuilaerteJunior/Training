import 'package:all_layouts_app/shared/menu_drawer.dart';
import 'package:flutter/material.dart';

class SecondLayout extends StatelessWidget {
  const SecondLayout({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'My Container app',
      home: Scaffold(           
        drawer: MenuDrawer(),
        appBar: AppBar(
          title: Text('Container'),          
        ),
        body: Column(
          children:[
            Container(
            //color: Colors.orange,
            margin: EdgeInsets.all(50),
            child: Text('Hello Container'),
            width: 100.00,
            height: 100.00,
            decoration: BoxDecoration(
              color: Colors.orange,
              shape: BoxShape.rectangle,
              gradient: LinearGradient(
                begin: Alignment(0, -1.0),
                end: Alignment(0, 1.0),
                //tileMode: TileMode.repeated,
                colors: [Colors.purple.shade50, Colors.purple.shade500 ]
              ),
              //borderRadius: BorderRadius.only(topLeft: Radius.circular(10)),
              borderRadius: BorderRadius.all(Radius.circular(10)),
        
            ),
            ),
            Container(            
                margin: EdgeInsets.all(50),                
                width: 200.00,
                height: 200.00,
                child: FlutterLogo(),
                decoration: BoxDecoration(
                  color: Colors.orange,
                  shape: BoxShape.rectangle,
                  gradient: RadialGradient(
                    tileMode: TileMode.clamp,
                    radius: 0.25,
                    center: Alignment(0, 0.8),
                    colors: [Colors.purple.shade50, Colors.purple.shade500 ]
                  ),
                  borderRadius: BorderRadius.all(Radius.circular(10)),
            
                ),
            ),
            Container(            
                margin: EdgeInsets.all(10),                
                width: 200.00,
                height: 350.00,
                decoration: BoxDecoration(
                  color: Colors.orange,
                  shape: BoxShape.rectangle,                  
                  gradient: LinearGradient(colors: [Colors.pink.shade50, Colors.pink.shade500]),
                  image: DecorationImage(
                    image: NetworkImage("http://bit.ly/flutter_tiger"),//openclipart.org
                    fit: BoxFit.scaleDown
                  ),
                  borderRadius: BorderRadius.all(Radius.circular(10)),
            
                ),
            )
          ]
        )
      )
    );
  }
}