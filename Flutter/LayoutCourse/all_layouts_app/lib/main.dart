import 'package:all_layouts_app/custom_layouts.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(AllLayouts());
}



//stless
class AllLayouts extends StatelessWidget {
  const AllLayouts({Key? key}): super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(primarySwatch: Colors.blueGrey),
      routes: {
        '/': (context) => CustomLayouts(),
      },
    );      
  }
}
