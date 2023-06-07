import pygame
import stale
from Platforma import Platforma
from Kulka import Kulka
from Klocek import Klocek

# Start
pygame.init()
pygame.font.init()

# Zmienne
ekran = pygame.display.set_mode((stale.SZEROKOSC_EKRANU, stale.WYSOKOSC_EKRANU))
zegar = pygame.time.Clock()
obraz_tla = pygame.image.load("images/background.png")
czcionka = pygame.font.SysFont("Comic Sans MS", 24)
zycia = 3
poziom = 0

poziom1 = [
    [0, 0, 1, 1, 1, 1, 1, 1, 0, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 1, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 1, 0],
    [0, 0, 1, 1, 1, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
]
poziom2 = [
    [0, 0, 1, 2, 3, 3, 2, 1, 0, 0],
    [0, 1, 1, 1, 2, 2, 1, 1, 1, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 1, 0],
    [0, 0, 1, 1, 1, 1, 1, 1, 0, 0],
    [0, 0, 2, 0, 0, 0, 0, 2, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 2, 0, 2, 0, 0, 2, 0, 2, 0],
]
poziom3 = [
    [2, 3, 2, 2, 2, 2, 2, 2, 3, 2],
    [2, 1, 3, 1, 1, 1, 1, 3, 1, 2],
    [2, 3, 1, 3, 1, 1, 3, 1, 3, 2],
    [3, 2, 2, 2, 3, 3, 2, 2, 2, 3],
    [0, 0, 2, 2, 3, 3, 2, 2, 0, 0],
    [0, 0, 2, 0, 3, 3, 0, 2, 0, 0],
    [0, 0, 3, 0, 3, 3, 0, 3, 0, 0],
]
poziom4 = [
    [2, 3, 2, 2, 2, 2, 2, 2, 3, 2],
    [2, 1, 3, 1, 1, 1, 1, 3, 1, 2],
    [2, 3, 1, 3, 1, 1, 3, 1, 3, 2],
    [3, 2, 2, 2, 3, 3, 2, 2, 2, 3],
    [0, 0, 2, 2, 3, 3, 2, 2, 0, 0],
    [0, 0, 2, 0, 3, 3, 0, 2, 0, 0],
    [0, 0, 3, 0, 3, 3, 0, 3, 0, 0],
]

klocki = pygame.sprite.Group()


def dodaj_klocki():
    wczytany_poziom = None
    if poziom == 0:
        wczytany_poziom = poziom1
    if poziom == 1:
        wczytany_poziom = poziom2
    if poziom == 2:
        wczytany_poziom = poziom3
    if poziom == 3:
        wczytany_poziom = poziom4

    for i in range(10):
        for j in range(7):
            if wczytany_poziom[j][i] != 0:
                klocek = Klocek(32 + i * 96, 32 + j * 48, wczytany_poziom[j][i])
                klocki.add(klocek)


dodaj_klocki()


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

    # Sprawdzanie
    if len(klocki.sprites()) == 0:
        poziom += 1
        if poziom >= stale.OSTATNI_POZIOM:
            break
        kulka.zresetuj_pozycje()
        platforma.zresetuj_pozycje()
        dodaj_klocki()

    # Aktualizacja
    kulka.aktualizuj(platforma, klocki)
    klocki.update()
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
    for klocek in klocki:
        klocek: Klocek = klocek
        ekran.blit(klocek.obraz, klocek.pozycja)

    # Tekst
    tekst = czcionka.render(f"Życia: {zycia}", False, (255, 0, 255))
    ekran.blit(tekst, (16, 16))

    # Koniec pętli
    pygame.display.flip()
    zegar.tick(stale.FPS)

# Koniec gry
pygame.quit()
