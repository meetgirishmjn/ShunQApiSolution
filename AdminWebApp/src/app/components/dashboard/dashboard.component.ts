import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  isLoadingItems = false;
  hasLoadError = false;

  constructor() { }

  ngOnInit() {
    
  }

  ngAfterViewInit() {
    setTimeout(() => {
      
    }, 0);
  }

  loadTestSchedules() {
    
  }

}
