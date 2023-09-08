import 'package:all_layouts_app/shared/menu_drawer.dart';
import 'package:flutter/material.dart';

class CustomLayouts extends StatelessWidget {
  const CustomLayouts({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(title: Text('Layouts')),
        drawer: MenuDrawer(),
        //bottomNavigationBar: BottomMenu(),
        body: Container(
          /*decoration: BoxDecoration(
            image: DecorationImage(
              image: AssetImage('assets/images/background.jpg'),
              fit: BoxFit.cover
            )
          ),*/
          child: Center(
            child: Container(
              padding: EdgeInsets.all(24),              
              decoration: BoxDecoration(
                borderRadius: BorderRadius.all(Radius.circular(20)),
                color: Colors.white70
              ),
              child: Text('Check layouts available through the drawer menu',
                textAlign: TextAlign.center,
                style: TextStyle(
                  fontSize: 22,
                  shadows: [
                    Shadow(
                      offset: Offset(1.0, 1.0),
                      blurRadius: 2.0,
                      color: Colors.grey
                    )
                  ]
                )
              )
            )
          ),
        ),
      );
  }
}