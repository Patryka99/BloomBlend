import Slider from 'react-slick';

export default function CatalogSlider() {
    const settings = {
        dots: true,
        infinite: true,
        speed: 500,
        slidesToShow: 1,
        slidesToScroll: 1
    };

    return (
        <>
            <Slider {...settings}>
                <div>
                    <img src="http://picsum.photos/154" alt='banner' 
                    style={{
                        display: 'block',
                        width: '90%',
                        maxHeight: 300,
                        margin: 'auto',
                        borderRadius: 30
                    }}
                    />
                </div>
                <div>
                    <img src="http://picsum.photos/643" alt='banner' 
                    style={{
                        display: 'block',
                        width: '90%',
                        maxHeight: 300,
                        margin: 'auto',
                        borderRadius: 30
                    }}
                    />
                </div>
                <div>
                    <img src="http://picsum.photos/234" alt='banner' 
                    style={{
                        display: 'block',
                        width: '90%',
                        maxHeight: 300,
                        margin: 'auto',
                        borderRadius: 30
                    }}
                    />
                </div>
            </Slider>
        </>
    )
}