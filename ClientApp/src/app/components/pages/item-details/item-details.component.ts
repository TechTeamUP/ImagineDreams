import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from '../../../services/products.service';
import { ProductDescription } from '../../../interfaces/item-product.interface';
import { SalesService } from 'src/app/services/sales.service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-itemdetails',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css'],
})
export class ItemDetailsComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    public productsService: ProductsService,
    private _SalesService: SalesService
  ) { }

  @Input() item: any;
  product: ProductDescription = {};
  id: string = '';
  // image: string = 'https://cdn.mos.cms.futurecdn.net/jbCNvTM4gwr2qV8X8fW3ZB.png';
  // title: string = 'Retrato el atardecer.';
  // description: string = 'A series of essential stationery format to showcase your branding projects. It includes a A6 flyer, A5 folder, A4 horizontal paper and a business card mockup. You can easily put your own graphics and create a new layout according to your needs.';
  // owner: string = 'Andrea Tanzi';
  // date: string = '18 April, 2022';
  // price: number = 20000;
  quantity: number = 3;
  reviews: any[] = [
    {
      name: 'David Smith',
      image:
        'https://cdn.domestika.org/c_fit,dpr_auto,f_auto,t_base_params,w_820/v1614314079/content-items/007/216/200/Thisperson-original.jpg?1614314079',
      review:
        'This product is great, of good quality and its deliveries are fast, I recommend it',
      instagram: 'da_smith',
    },
    {
      name: 'Camilo Soto',
      image:
        'https://cdn.pixabay.com/photo/2014/07/09/10/04/man-388104_640.jpg',
      review:
        'This product is great, of good quality and its deliveries are fast, I recommend it',
      instagram: 'camilosoto',
    },
    {
      name: 'Juan Carlos',
      image:
        'https://cdn.pixabay.com/photo/2020/07/22/04/27/man-5428005_1280.jpg',
      review:
        'This product is great, of good quality and its deliveries are fast, I recommend it',
      instagram: 'juan_carlos',
    },
  ];

  ngOnInit(): void {

    this.route.params.subscribe((params) => {
      this.productsService
        .getProduct(params['id'])
        .subscribe((product: ProductDescription) => {
          this.id = params['id'];
          this.product = product;
        });
    });
    this.initData();
  }

  // Variables
  quantityValue: number = 1;

  // // Methods
  initData() {
    //   this.image = this.item.image;
    //   this.title = this.item.title;
    //   this.description = this.item.description;
    //   this.owner = this.item.owner;
    //   this.price = this.item.price;
    this.quantity = this.item.quantity;
    //   this.reviews = this.item.reviews;
  }

  increaseQuantity() {
    if (this.quantityValue < this.quantity) {
      this.quantityValue++;
    }
  }

  decrementQuantity() {
    if (this.quantityValue > 1) {
      this.quantityValue--;
    }
  }

  sales(itemProduct: any, quantity: any) {

    var body =
    {
      Quantity: quantity,
      Total: itemProduct.price,
      UserId: 1,
      ProductId: 1,
      StateId: 1
    }
    this._SalesService.sales(body).subscribe(response => {
      console.log("pase sapoprro");
    }, error => {
      console.log(error);
    }
    )
  }
}
