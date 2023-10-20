import { Container } from '@mui/material';
import Slider from 'react-slick';
import './Carousel.css';

export default function CatalogSlider() {
    const settings = {
        dots: false,
        infinite: true,
        autoplay: true,
        speed: 500,
        slidesToShow: 1,
        slidesToScroll: 1
    };

    return (
        <Container maxWidth={false} sx={{width: '80%', mb: 3}}>
            <Slider {...settings}>
                <div>
                    <img src="/images/banner/Banner1.png" alt='banner' 
                    style={{
                        display: 'block',
                        width: '98%',
                        maxHeight: 250,
                        margin: 'auto',
                        borderRadius: 30
                    }}
                    />
                </div>
                <div>
                    <img src="/images/banner/Banner2.png" alt='banner' 
                    style={{
                        display: 'block',
                        width: '98%',
                        maxHeight: 250,
                        margin: 'auto',
                        borderRadius: 30
                    }}
                    />
                </div>
                <div>
                    <img src="/images/banner/Banner3.png" alt='banner' 
                    style={{
                        display: 'block',
                        width: '98%',
                        maxHeight: 250,
                        margin: 'auto',
                        borderRadius: 30
                    }}
                    />
                </div>
            </Slider>
        </Container>
    )
}