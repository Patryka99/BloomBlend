import { Copyright, Facebook, GitHub, LinkedIn } from "@mui/icons-material";
import { Box, Container, Divider, Grid, IconButton, Typography } from "@mui/material";
import { Link, NavLink } from "react-router-dom";

export default function FooterPage() {
    return (
        <Container maxWidth={false} sx={{ mb: 3, width: '80%', bottom: 0 }}>
            <Divider sx={{
                backgroundColor: 'primary.dark',
                mt: 2,
                borderBottomWidth: 4,
                mb: 4,
            }} />
            <Grid container spacing={3} sx={{ display: 'flex', justifyContent: 'space-between', }}>
                <Grid item xs={6}>
                    <Typography variant="h4" color='primary.dark' sx={{ fontWeight: 'bold', pl: 10 }}>BloomBlend</Typography>
                    <Typography variant='body1' sx={{ pl: 10 }}>BloomBlend. Vestibulum non est nisl. <br></br>
                        Donec eget sodales nisl. Donec ut velit erat.</Typography>
                    <Typography sx={{ pl: 10 }} variant="h6" display='flex' alignItems='center' alignContent='center'><Copyright />&nbsp; 2023 All rights reserved.</Typography>
                </Grid>
                <Grid item xs={3} display='flex' flexDirection='column'  sx={{ textAlign: 'end', alignItems: 'end' }}>
                    <Typography variant="body1" color='text.primary' component={NavLink} to={'/catalog'} sx={{ pr: 10 }}>Explore</Typography>
                    <Typography variant="body1" color='text.primary' component={NavLink} to={'/catalog'} sx={{ pr: 10 }}>Products</Typography>
                    <Typography variant="body1" color='text.primary' sx={{ pr: 10 }}>Reviews</Typography>
                </Grid>
                <Grid item xs={3} display='flex' flexDirection='column' sx={{ textAlign: 'end', alignItems: 'end' }}>
                    <Typography variant="body1" color='text.primary' component={NavLink} to={'/contact'} sx={{ pr: 10 }}>Contact</Typography>
                    <Typography variant="body1" color='text.primary' component={NavLink} to={'/about'} sx={{ pr: 10 }}>About</Typography>
                    <Typography variant="body1" color='text.primary'  sx={{ fontWeight: 'bold', pr: 10 }}>Social Media</Typography>
                    <Box sx={{ pr: 10 }}>
                        <IconButton aria-label="delete" target="_blank" component={Link} to='https://github.com/Patryka99/BloomBlend'>
                            <GitHub />
                        </IconButton>
                        <IconButton aria-label="delete" target="_blank" component={Link} to='https://www.facebook.com/Patryk.Are'>
                            <Facebook />
                        </IconButton>
                        <IconButton aria-label="delete" target="_blank" component={Link} to='https://www.linkedin.com/in/patryk-arendt-030a38185/'>
                            <LinkedIn />
                        </IconButton>

                    </Box>
                </Grid>
            </Grid>
        </Container>
    )
}