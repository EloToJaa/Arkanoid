import pygame
import random
import stale

vec = pygame.math.Vector2


class Kulka(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()
        self.obraz = pygame.image.load("images/ball.png")
        self.zresetuj_pozycje()
        self.r = 16
        self.przegrana = False

    def zresetuj_pozycje(self):
        self.wspolrzedne = vec(stale.SZEROKOSC_EKRANU / 2, stale.WYSOKOSC_EKRANU - 140)
        self.pozycja = self.obraz.get_rect(center=self.wspolrzedne)
        self.wektor = vec(0, -10)
        self.kat_nachylenia = random.randint(-30, 30)
        self.wektor.rotate_ip(self.kat_nachylenia)
        self.przegrana = False

    def aktualizuj(self, platforma):
        self.wspolrzedne += self.wektor
        self.pozycja.center = self.wspolrzedne
