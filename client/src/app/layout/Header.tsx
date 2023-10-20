import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, Box, Divider, IconButton, List, ListItem, Switch, Toolbar, Typography } from "@mui/material";
import { Link, NavLink } from "react-router-dom";
import { useAppSelector } from "../store/configureStore";
import SignedInMenu from "./SignedInMenu";

const midLinks = [
    { title: 'catalog', path: '/catalog' },
    { title: 'about', path: '/about' },
    { title: 'contact', path: '/contact' },
]

const rightLinks = [
    { title: 'login', path: '/login' },
    { title: 'register', path: '/register' },
]

const navStyles = {
    color: 'inherit',
    textDecoration: 'none',
    typography: 'h6',
    '&:hover': {
        color: 'grey.500',
        textDecoration: 'overline',
        textUnderlineOffset: 8
    },
    '&.active': {
        color: 'primary.main',
        textDecoration: 'underline',
        textUnderlineOffset: 8
    }
}

const navStyles2 = {
    color: 'primary.dark',
    textDecoration: 'none',
    typography: 'h6',
    '&:hover': {
        color: 'grey.500',
        textDecoration: 'overline',
        textUnderlineOffset: 8
    },
    '&.active': {
        color: 'primary.main',
        textDecoration: 'underline',
        textUnderlineOffset: 8
    }
}

const divider = {
    backgroundColor: 'primary.dark',
    mt: 2,
    borderBottomWidth: 4
}


interface Props {
    darkMode: boolean;
    handleThemeChange: () => void;
}

export default function Header({ darkMode, handleThemeChange }: Props) {
    const { basket } = useAppSelector(state => state.basket);
    const { user } = useAppSelector(state => state.account);
    const itemCount = basket?.items.reduce((sum, item) => sum + item.quantity, 0);

    return (
        <AppBar elevation={0} position="static" sx={{
            width: 3 / 4,
            justifyContent: 'center',
            margin: 'auto',
            marginTop: 3,
            background: 'transparent',
            color: 'inherit',
            mb: 4,
        }}>
            <Toolbar sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                <Box display='flex' alignItems='center'>
                    <Typography variant='h6' component={NavLink} to='/'
                        sx={{
                            color: 'inherit', textDecoration: 'none'
                        }}
                    >
                        Bloom-Blend
                    </Typography>
                    <Switch checked={darkMode} onChange={handleThemeChange} />
                </Box>

                <Box display='flex' alignItems='center'>
                    <List sx={{ display: 'flex' }}>
                        {midLinks.map(({ title, path }) => (
                            <ListItem
                                component={NavLink}
                                to={path}
                                key={path}
                                sx={navStyles}
                            >
                                {title.toUpperCase()}
                            </ListItem>
                        ))}
                        {user && user.roles?.includes('Admin') &&
                        <ListItem
                            component={NavLink}
                            to={'/inventory'}
                            sx={navStyles}
                        >
                            Inventory
                        </ListItem>}
                    </List>
                </Box>

                <Box display='flex' alignItems='center'>
                    <IconButton component={Link} to='/basket' size='large' edge='start' sx={{ mr: 2, color: 'primary.dark' }}>
                        <Badge badgeContent={itemCount} color='primary'>
                            <ShoppingCart />
                        </Badge>
                    </IconButton>
                    {user ? (
                        <SignedInMenu />
                    ) : (<List sx={{ display: 'flex' }}>
                        {rightLinks.map(({ title, path }) => (
                            <ListItem
                                component={NavLink}
                                to={path}
                                key={path}
                                sx={navStyles2}
                            >
                                {title.toUpperCase()}
                            </ListItem>
                        ))}
                    </List>)}
                </Box>
            </Toolbar>
            <Divider variant="middle" sx={divider} />
        </AppBar>
    )
}