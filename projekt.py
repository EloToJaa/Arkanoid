import pygame
import stale
from Platforma import Platforma
from Kulka import Kulka

# Zmienne
ekran = pygame.display.set_mode((stale.SZEROKOSC_EKRANU, stale.WYSOKOSC_EKRANU))
zegar = pygame.time.Clock()
obraz_tla = pygame.image.load("images/background.png")
zycia = 3

# Obiekty
platforma = Platforma()
kulka = Kulka()

# Pętla
gra_dziala = True
while gra_dziala:
    # Zdarzenia
    for zdarzenia in pygame.event.get():
        if zdarzenia.type == pygame.KEYDOWN:
            if zdarzenia.key == pygame.K_ESCAPE:
                gra_dziala = False
        elif zdarzenia.type == pygame.QUIT:
            gra_dziala = False

    # Sterowanie
    keys = pygame.key.get_pressed()
    if keys[pygame.K_a]:
        platforma.ruszaj_platforma(-1)
    if keys[pygame.K_d]:
        platforma.ruszaj_platforma(1)

    # Aktualizacja
    kulka.aktualizuj(platforma)
    platforma.aktualizuj()
    if kulka.przegrana:
        zycia -= 1
        if zycia <= 0:
            gra_dziala = False
        kulka.zresetuj_pozycje()
        platforma.zresetuj_pozycje()

    # Rysowanie
    ekran.blit(obraz_tla, (0, 0))
    ekran.blit(platforma.surf, platforma.pozycja)
    ekran.blit(kulka.obraz, kulka.pozycja)

    # Koniec pętli
    pygame.display.flip()
    zegar.tick(stale.FPS)

# Koniec gry
pygame.quit()
