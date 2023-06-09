import pygame
import stale


class Platforma(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()
        self.surf = pygame.image.load("images/pad.png")
        self.porusza_sie = 0
        self.zresetuj_pozycje()

    def zresetuj_pozycje(self):
        self.pozycja = pygame.Rect(
            stale.SZEROKOSC_EKRANU / 2 - 70, stale.WYSOKOSC_EKRANU - 100, 140, 30
        )

    def ruszaj_platforma(self, wartosc: int):
        predkosc = 10
        self.pozycja.move_ip(wartosc * predkosc, 0)
        self.porusza_sie = wartosc

        if self.pozycja.left <= 0:
            self.pozycja.x = 0
        if self.pozycja.right >= stale.SZEROKOSC_EKRANU:
            self.pozycja.x = stale.SZEROKOSC_EKRANU - 140

    def aktualizuj(self):
        self.porusza_sie = 0
