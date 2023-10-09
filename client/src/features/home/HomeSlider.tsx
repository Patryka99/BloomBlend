import { Container } from '@mui/material';
import Slider from 'react-slick';
import './home.css';

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
        <Container maxWidth={false} sx={{width: '90%', mb: 3}}>
            <Slider {...settings}>
                <div>
                    <img src="/images/1.png" alt='banner' 
                    style={{
                        display: 'block',
                        width: '100%',
                        maxHeight: 700,
                        margin: 'auto',
                        borderRadius: 30
                    }}
                    />
                </div>
                <div>
                    <img src="/images/2.png" alt='banner' 
                    style={{
                        display: 'block',
                        width: '100%',
                        maxHeight: 700,
                        margin: 'auto',
                        borderRadius: 30
                    }}
                    />
                </div>
            </Slider>
        </Container>
    )
}