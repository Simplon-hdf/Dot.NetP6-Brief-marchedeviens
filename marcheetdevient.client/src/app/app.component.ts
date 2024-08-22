import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Form } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  constructor(private router: Router) { }
  allerPage(nomPage: string): void {
    this.router.navigate([`${nomPage}`]);
  }
}

document.addEventListener("DOMContentLoaded", () => {
  let currentIndex = 0;
  const items = document.querySelectorAll(".carousel-item");

  function showItem(index: number) {
      items.forEach((item, i) => {
          if (i === index) {
              item.classList.add("active");
          } else {
              item.classList.remove("active");
          }
      });
  }

  document.getElementById("prev-btn")?.addEventListener("click", () => {
      currentIndex = (currentIndex > 0) ? currentIndex - 1 : items.length - 1;
      showItem(currentIndex);
  });

  document.getElementById("next-btn")?.addEventListener("click", () => {
      currentIndex = (currentIndex < items.length - 1) ? currentIndex + 1 : 0;
      showItem(currentIndex);
  });

  // Initial display
  showItem(currentIndex);
});

