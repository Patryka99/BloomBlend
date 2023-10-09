import { Box, Container, Typography } from "@mui/material";
import './home.css';
import HomeSlider from "./HomeSlider";

export default function HomePage() {
    return (
        <Container maxWidth={false} sx={{ width: '80%' }}>
            <HomeSlider />
            <Box display='flex' justifyContent='center' alignContent='center' alignItems='center' justifyItems='center'
                sx={{
                }}
            >
                <Typography variant="h3" sx={{
                    backgroundColor: 'grey.300',
                    pl: 10,
                    pr: 10,
                    mt: -10,
                    zIndex: 99,
                    borderRadius: '20px',
                    border: '1px solid grey',
                    color: 'black'
                }}>
                    Over <span style={{
                        color: 'blue',
                        fontWeight: 'bold',
                        fontSize: '200%'
                    }}>10</span> products for every occasion
                </Typography>
            </Box>
        </Container>
    )
}