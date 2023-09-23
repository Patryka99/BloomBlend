import { Box, Button, Container, Divider, Grid, Paper, Typography } from "@mui/material";
import { Link } from "react-router-dom";

export default function NotFound() {
    return (
        <Container maxWidth={false} component={Paper} sx={{ height: '70vh', width: '80%' }}>
                    <Box display='flex' justifyContent='center' alignItems='center' height='70vh'>
                        <Typography textAlign='center' variant="h3" color='primary'>
                            There is nothing to looking for...
                        </Typography>
                        <img src="/images/404.png" alt="Not found" width='600px'/>
                        <Button size='large' variant='contained' sx={{width: '400px'}} component={Link} to='/catalog'>Go back go back</Button>
                    </Box>
        </Container>
    )
}