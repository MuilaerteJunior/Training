import 'package:all_layouts_app/custom_layouts.dart';
import 'package:all_layouts_app/first_layout.dart';
import 'package:all_layouts_app/fourth_layout.dart';
import 'package:all_layouts_app/second_layout.dart';
import 'package:all_layouts_app/third_layout.dart';
import 'package:flutter/material.dart';

import '../fifth_layout.dart';
import '../pizza_layout.dart';

class MenuDrawer extends StatelessWidget {
  const MenuDrawer({super.key});

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        children: buildMenuItems(context)
        )
      );
  }
  
  List<Widget> buildMenuItems(BuildContext context){
    final List<String> menuTitles = [
      "Home",
      "First",
      "Second",
      "Third",
      "Fourth",
      "Fifth",
      "Pizza"
    ];

    List<Widget> menuItems = [];
    menuItems.add(DrawerHeader(
      decoration: BoxDecoration(color: Colors.blueGrey),
        child: Text ('Layouts availables',  style: TextStyle(color: Colors.white70, fontSize: 20))
    ));

    menuTitles.forEach((element) {
      Widget screen = Container();
      menuItems.add(ListTile(
        title: Text(element, style: TextStyle(fontSize: 18)),
        onTap: (){
          switch (element) {  
            case 'First':
              screen = FirstLayout();
              break;              
            case 'Second':
              screen = SecondLayout();
              break;              
            case 'Third':
              screen = ThirdLayout();
              break;
            case 'Fourth':
              screen = FourthLayout();
              break; 
            case 'Fifth':
              screen = FifthLayout();
              break;              
            case 'Pizza':
              screen = PizzaLayout();
              break;    
            case 'Home':
            default: 
              screen = CustomLayouts();
              break;
          }

          Navigator.of(context).pop();//Removing the drawer from screen
          Navigator.of(context).push(
            MaterialPageRoute(builder: (context) => screen)
          );
        }
      ));
    });
    return menuItems;
  }
}
