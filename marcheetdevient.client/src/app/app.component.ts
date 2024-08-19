import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {NavigationEnd, Router} from '@angular/router';


interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit{
  constructor(private router:Router) {}

  ngOnInit() {
    this.router.events.subscribe((event) => {
        if (!(event instanceof NavigationEnd)) {
            return;
        }
        window.scrollTo(0, 0)
    });
  }
  allerPage(nomPage:string):void{
    this.router.navigate([`${nomPage}`]);
  }
}
