<<<<<<< HEADimport { HttpClient } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
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
export class AppComponent{

  constructor(private router:Router) {}
  allerPage(nomPage:string):void{
    this.router.navigate([`${nomPage}`]);
  }
}
=======
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, OnInit } from '@angular/core';
import {Router} from '@angular/router';


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
export class AppComponent{
  constructor(private router:Router) {}
  allerPage(nomPage:string):void{
    this.router.navigate([`${nomPage}`]);
  }
}
>>>>>>> b278f52 (feat:page offre mokup)
