import { Component, OnInit } from '@angular/core';
import { AppContext } from '../../services/AppContext';

@Component({
  templateUrl: './storeSearch.component.html',
  styleUrls: ['./storeSearch.component.css']
})
export class StoreSearchComponent implements OnInit {

  isLoadingItems = false;
  hasLoadError = false;

  constructor(app:AppContext) { }

  ngOnInit() {
  }

  ngAfterViewInit() {
    setTimeout(() => {
      
    }, 0);
  }

  loadTestSchedules() {
    
  }

}
