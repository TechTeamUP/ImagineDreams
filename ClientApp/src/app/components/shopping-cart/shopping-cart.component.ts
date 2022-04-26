import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  // Variables
  quantityValue: number = 0;

  quantity: number = 3;
  cartItems: any[] = [
    {
      image: 'https://cdn.mos.cms.futurecdn.net/jbCNvTM4gwr2qV8X8fW3ZB.png',
      title: 'Retrato el atardecer',
      description: 'A series of essential stationery format to showcase your branding projects. It includes a A6 flyer, A5 folder, A4 horizontal paper and a business card mockup. You can easily put your own graphics and create a new layout according to your needs.',
      owner: 'Andrea Tanzi',
      date: '18 April, 2022',
      price: 20000,
      quantity: 3,
      ref: 'ABC-1',
      user_quantity: 1,
      reviews: [
        {
          name: 'David Smith',
          image: 'https://cdn.domestika.org/c_fit,dpr_auto,f_auto,t_base_params,w_820/v1614314079/content-items/007/216/200/Thisperson-original.jpg?1614314079',
          review: 'This product is great, of good quality and its deliveries are fast, I recommend it',
          instagram: 'da_smith',
        },
        {
          name: 'Camilo Soto',
          image: 'https://cdn.pixabay.com/photo/2014/07/09/10/04/man-388104_640.jpg',
          review: 'This product is great, of good quality and its deliveries are fast, I recommend it',
          instagram: 'camilosoto',
        },
        {
          name: 'Juan Carlos',
          image: 'https://cdn.pixabay.com/photo/2020/07/22/04/27/man-5428005_1280.jpg',
          review: 'This product is great, of good quality and its deliveries are fast, I recommend it',
          instagram: 'juan_carlos',
        }
      ]
    },
    {
      image: 'https://www.u-buy.jp/productimg/?image=aHR0cHM6Ly9tLm1lZGlhLWFtYXpvbi5jb20vaW1hZ2VzL0kvOTF1eWxGQ2cyeUwuX1NMMTUwMF8uanBn.jpg',
      title: 'Melody of the night',
      description: 'A series of essential stationery format to showcase your branding projects. It includes a A6 flyer, A5 folder, A4 horizontal paper and a business card mockup. You can easily put your own graphics and create a new layout according to your needs.',
      owner: 'David Smith',
      date: '18 April, 2022',
      price: 50000,
      quantity: 5,
      ref: 'ABC-2',
      user_quantity: 2,
      reviews: [
        {
          name: 'David Smith',
          image: 'https://cdn.domestika.org/c_fit,dpr_auto,f_auto,t_base_params,w_820/v1614314079/content-items/007/216/200/Thisperson-original.jpg?1614314079',
          review: 'This product is great, of good quality and its deliveries are fast, I recommend it',
          instagram: 'da_smith',
        },
        {
          name: 'Camilo Soto',
          image: 'https://cdn.pixabay.com/photo/2014/07/09/10/04/man-388104_640.jpg',
          review: 'This product is great, of good quality and its deliveries are fast, I recommend it',
          instagram: 'camilosoto',
        },
        {
          name: 'Juan Carlos',
          image: 'https://cdn.pixabay.com/photo/2020/07/22/04/27/man-5428005_1280.jpg',
          review: 'This product is great, of good quality and its deliveries are fast, I recommend it',
          instagram: 'juan_carlos',
        }
      ]
    },
    {
      image: 'https://www.ubuy.vn/productimg/?image=aHR0cHM6Ly9tLm1lZGlhLWFtYXpvbi5jb20vaW1hZ2VzL0kvODFDejZaRys3akwuX0FDX1NMMTMzM18uanBn.jpg',
      title: 'Rainy street',
      description: 'A series of essential stationery format to showcase your branding projects. It includes a A6 flyer, A5 folder, A4 horizontal paper and a business card mockup. You can easily put your own graphics and create a new layout according to your needs.',
      owner: 'Steven Smith',
      date: '31 March, 2022',
      price: 24000,
      quantity: 6,
      ref: 'ABC-3',
      user_quantity: 1,
      reviews: [
        {
          name: 'David Smith',
          image: 'https://cdn.domestika.org/c_fit,dpr_auto,f_auto,t_base_params,w_820/v1614314079/content-items/007/216/200/Thisperson-original.jpg?1614314079',
          review: 'This product is great, of good quality and its deliveries are fast, I recommend it',
          instagram: 'da_smith',
        },
        {
          name: 'Camilo Soto',
          image: 'https://cdn.pixabay.com/photo/2014/07/09/10/04/man-388104_640.jpg',
          review: 'This product is great, of good quality and its deliveries are fast, I recommend it',
          instagram: 'camilosoto',
        },
        {
          name: 'Juan Carlos',
          image: 'https://cdn.pixabay.com/photo/2020/07/22/04/27/man-5428005_1280.jpg',
          review: 'This product is great, of good quality and its deliveries are fast, I recommend it',
          instagram: 'juan_carlos',
        }
      ]
    }
  ];

  // increaseQuantity(max: number, quantity: number): number {
  //   if (quantity < max) {
  //     quantity++;
  //   }
  //   return quantity;
  // }

  // decrementQuantity(quantity: number): number {
  //   if (quantity > 0) {
  //     quantity--;
  //   }
  //   return quantity;
  // }

  increaseQuantity() {
    if (this.quantityValue < this.quantity) {
      this.quantityValue++;
    }
  }

  decrementQuantity() {
    if (this.quantityValue > 0) {
      this.quantityValue--;
    }
  }

}
