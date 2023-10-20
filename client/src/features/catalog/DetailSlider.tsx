import Slider from 'react-slick';
import './Carousel.css';

interface Props {
    pictureUrl: string;
    pictureUrl2: string;
    pictureUrl3: string;
}

export default function DetailSlider({ pictureUrl, pictureUrl2, pictureUrl3 }: Props) {
    const data = [ pictureUrl, pictureUrl2, pictureUrl3 ]
    const settings = {
        fade: true,
        autoplay: true,
        arrows: false,
        dots: true,
        dotsClass: "slick-dots custom-indicator",
        infinite: true,
        speed: 1000,
        slidesToShow: 1,
        slidesToScroll: 1,
        customPaging: function (i: number) {
            return (
                <div>
                    <img src={data[i]} alt="test" style={{
                        width: '80px',
                        height: '90px',
                        objectFit: 'fill',
                        borderRadius: '10px'
                    }}/>
                </div>
            );
        },
    };

    return (
        <>
            <Slider {...settings}>
                <div>
                    <img src={pictureUrl} alt='banner'
                        style={{
                            display: 'block',
                            width: '70%',
                            maxHeight: 650,
                            margin: 'auto',
                            borderRadius: 30,
                        }}
                    />
                </div>
                <div>
                    <img src={pictureUrl2} alt='banner'
                        style={{
                            display: 'block',
                            width: '70%',
                            maxHeight: 650,
                            margin: 'auto',
                            borderRadius: 30
                        }}
                    />
                </div>
                <div>
                    <img src={pictureUrl3} alt='banner'
                        style={{
                            display: 'block',
                            width: '70%',
                            maxHeight: 650,
                            margin: 'auto',
                            borderRadius: 30
                        }}
                    />
                </div>
            </Slider>
        </>
    )
}