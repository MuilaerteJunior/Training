import 'package:all_layouts_app/shared/menu_drawer.dart';
import 'package:flutter/material.dart';

class FirstLayout extends StatelessWidget {
  const FirstLayout({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
        brightness: Brightness.dark,
        /*
        colorScheme: ColorScheme(brightness: Brightness.dark,
          primary:  Color(0xff009688), 

          secondary: Color(0xff7C4DFF), 
        ),*/
        primaryColor: Color(0xff009688), 
        //secondaryHeaderColor:,
        textTheme: TextTheme(
          bodyText2: TextStyle(
            fontSize: 24,
            fontStyle: FontStyle.italic
          )
        )
        //accentColor: Color(0xff009688),
        //primaryColor: Color(0xff009688),
      ),
      home: Scaffold(appBar: AppBar(title: Text('Building layouts with Flutter'),),     
        drawer: MenuDrawer(),
        body: Center(child: 
          Text('Hello Flutter layouts',
          style: TextStyle(fontSize: 24))
        ),
        floatingActionButton: FloatingActionButton(
          child: Icon(Icons.lightbulb_outline),
          onPressed: () {
            print('You rang?');
          },
        ),
        persistentFooterButtons: <Widget>[
          IconButton(onPressed: (){}, icon: Icon(Icons.add_comment)),
          IconButton(onPressed: (){}, icon: Icon(Icons.add_alarm)),
          IconButton(onPressed: (){}, icon: Icon(Icons.add_location)),
        ]
        ,
      )
    );
  }
}